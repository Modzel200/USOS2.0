import { HttpClient } from '@angular/common/http'; 
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Admin } from '../models/admin.component';

@Injectable({
    providedIn: 'root'
})
export class UserService{
    baseUrl = 'https://localhost:7158/api/admin';

    constructor(private http: HttpClient) { }
    createUser(user: Admin): Observable<Admin>{
        user.id='0';
        return this.http.post<Admin>(this.baseUrl,user);
    }
}