import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AuthService } from './auth.service';
import { EndpointBase } from './endpoint-base.service';
import { Observable } from 'rxjs/internal/Observable';
import { catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService extends EndpointBase {


  constructor(http: HttpClient, authService: AuthService) {
    super(http, authService);
  }

  getCustomersList<T>(): Observable<T> {
    
    return this.http.get<T>('https://localhost:7211/api/Customer', this.requestHeaders).pipe(
      catchError(error => {
        return this.handleError(error, () => this.getCustomersList<T>());
      }));
  }

  Save<Customer>(cutomer: object): Observable<Customer> {
    return this.http.post<Customer>('https://localhost:7211/api/Customer', JSON.stringify(cutomer), this.requestHeaders).pipe(
      catchError(error => {
        return this.handleError(error, () => this.Save<Customer>(cutomer));
      }));
  }
}
