import { HttpClient } from '@angular/common/http'; 
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class UserService{
    baseUrl = 'https://localhost:7158/api/user';

    constructor(private http: HttpClient) { }
}