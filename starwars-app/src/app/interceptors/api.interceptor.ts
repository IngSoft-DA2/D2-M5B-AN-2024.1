import {Injectable} from '@angular/core';
import {HttpEvent, HttpInterceptor, HttpHandler, HttpRequest} from '@angular/common/http';
import {Observable} from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class APIInterceptor implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    console.log('req antes de aplicar el interceptor', req.url)
    //url = 'characters'
    //https://localhost:5222 
    const apiReq = req.clone({ url: `${environment.API_HOST_URL}/${req.url}` });
    console.log('req despues de aplicar el interceptor', apiReq.url)
    return next.handle(apiReq);
  }
}