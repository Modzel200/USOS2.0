import { HttpClient } from '@angular/common/http'; 
import { Injectable } from '@angular/core';
import { Lecturer } from '../models/lecturer.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class LecturerService {
    baseUrl = 'https://localhost:7158/api/lecturer';

    constructor(private http: HttpClient) { }
    getAllLecturers(): Observable<Lecturer[]> {
        return this.http.get<Lecturer[]>(this.baseUrl);
    }
    addLecturer(lecturer: Lecturer): Observable<Lecturer> {
        lecturer.id = '0';
        return this.http.post<Lecturer>(this.baseUrl, lecturer);
      }
}
