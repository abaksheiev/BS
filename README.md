# Fake blogging system(CQRS)

```html
- Start project: BS.Init 
- Docker image : abaksheiev/bsinit
- Settings
	- IS_SWAGGER_ACTIVATED: True // Activate swagger, default value false

```

Run Docker Container
```html
docker run  --env=IS_SWAGGER_ACTIVATED=True -p 8181:8080 -d abaksheiev/bsinit:latest
```

Check healthy
```html
http://localhost:8181/healthz
```

Example of POST
```html
$ curl -X 'POST' \
  'http://localhost:8181/api/v1/Posts' \
  -H 'accept: application/json' \
  -H 'Content-Type: application/json' \
  -d '{
    "title": "Sample Title",
    "description": "This is a sample description.",
    "content": "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
    "author": {
        "name": "John",
        "surname": "Doe"
    }
}'
```

```html
{
   "id":"3a46b153-05eb-4cd5-8893-01bfa9005858",
   "title":"Sample Title",
   "description":"This is a sample description.",
   "content":"Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
   "author":{
      "id":"5b95480d-bca8-452a-a022-88e36ff41569",
      "name":"John",
      "surname":"Doe"
   }
}
```

Example of GET(with author)

```html
curl -X 'GET' \
  'http://localhost:8181/api/v1/Posts/3d6815d5-c8d2-44ff-847c-b9bf0fbcb53a?ai=true' \
  -H 'accept: application/json'
```

```html
{
   "id":"3d6815d5-c8d2-44ff-847c-b9bf0fbcb53a",
   "title":"Sample Title",
   "description":"This is a sample description.",
   "content":"Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
   "author":{
      "id":"f493730f-5619-4f38-8ff8-b219f01cde4f",
      "name":"John",
      "surname":"Doe"
   }
}
```
Solution Design 

![Coverage](https://github.com/abaksheiev/BS/blob/master/imgs/Design.png)

Code coverage: https://github.com/FortuneN/FineCodeCoverage/releases

![Coverage](https://github.com/abaksheiev/BS/blob/master/imgs/Coverage.png)

![Summary](https://github.com/abaksheiev/BS/blob/master/imgs/Summary.png)
