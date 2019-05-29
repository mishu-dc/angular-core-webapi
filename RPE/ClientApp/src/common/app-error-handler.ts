import { ErrorHandler, Injectable } from "@angular/core";

@Injectable()
export class AppErrorHandler extends ErrorHandler {
    handleError(error){
        console.log('An unexpected error has happened');
        console.log(error);
    }
}