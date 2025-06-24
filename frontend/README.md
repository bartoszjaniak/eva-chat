# Frontend

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 17.0.10.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## API URL configuration

The API URL is configured using environment variables. To set the API URL:

1. Edit the `.env.development` file (for development) or `.env` (for production build) in the `frontend` directory:

```
NG_APP_API_URL=http://localhost:5278
```

2. The Angular app will use this value as the API base URL. If not set, it defaults to `http://localhost:5278`.

3. After changing the value, restart the dev server or rebuild the app:
   - For development: `ng serve`
   - For production: `ng build --configuration production`

The value is injected at build time using the `@ngx-env/builder` package.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.io/cli) page.
