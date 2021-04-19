# Capstone project for PI1

## Software requirements

- NodeJS
- NPM
- dotnet core
- C#

## Technologies 

Frontend technologies:

- Framework: VueJS
- Language: TypeScript
- Testing: Jest
- Bundler: Babel
- CSS preprocessor: SASS


Backend technologies:

- Framework: .NET Core
- .NET Core

## Documentation

[Documentation folder here](https://drive.google.com/drive/folders/1Sp_ACY3OxSw0wXTZ3ey-G_qhQ40Rf5wv?usp=sharing)


## Setup

### Frontend

For a better frontend develoeper experience, look:
[vue-devtools](https://github.com/vuejs/vue-devtools#vue-devtools)

#### Project setup
From root project directory:
```
cd /frontend && npm install
```

#### Compiles and hot-reloads for development
From root project directory:
```
cd /frontend && npm run serve
```

#### Compiles and minifies for production
From root project directory:
```
cd /frontend && npm run build
```

#### Run unit tests
From root project directory:
```
cd /frontend && npm run test:unit
```

#### Run end-to-end tests
First start the server from `/backend` folder:
```
dotnet run
```
Then from `/frontend` folder:
```
npm run test:e2e
```

### Backend
#### To run the server app:
```
cd /backend && dotnet run
```

#### To run the back-end tests:
```
cd /backend/tests && dotnet test
```

###### Note:
The frontend URL is: https://localhost:5001/, not https://localhost:8080/.
