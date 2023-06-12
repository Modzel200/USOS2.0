import { HttpClient } from '@angular/common/http'; 
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../models/login.model';
@Injectable({
    providedIn: 'root'
})
export class LoginService{
    baseUrl = 'https://localhost:7158/api/admin/login';
    constructor(private http: HttpClient) { }
    login(account: Login): Observable<boolean>{
        return this.http.post<boolean>(this.baseUrl,account);
    }
}