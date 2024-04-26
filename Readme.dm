# Fake blogging system(CQRS)
```html
Code coverage: https://github.com/FortuneN/FineCodeCoverage/releases
<img src="/imgs/Coverage.png">

<img src="/imgs/Summary.png">

Docker
- Docker file is in BS.Init project
- Docker image : abaksheiev/bsinit
- Settings
	- IS_SWAGGER_ACTIVATED: True // Activate swagger, default value false
- [:]/healthz // check if application was running susscessfully
```

Run image:
docker run  --env=IS_SWAGGER_ACTIVATED=True -p 8181:8080 -d abaksheiev/bsinit:latest


Insert Post
```html
<!-- Navigation -->
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
<!-- /Navigation -->
```

```html
<!-- Navigation -->
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
<!-- /Navigation -->
```

Get Post With Athor

```html
<!-- Navigation -->
curl -X 'GET' \
  'http://localhost:8181/api/v1/Posts/3d6815d5-c8d2-44ff-847c-b9bf0fbcb53a?ai=true' \
  -H 'accept: application/json'
<!-- /Navigation -->
```

```html
<!-- Navigation -->
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
<!-- /Navigation -->
```
