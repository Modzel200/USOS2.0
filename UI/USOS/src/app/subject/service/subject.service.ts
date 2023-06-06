import { HttpClient } from '@angular/common/http'; 
import { Injectable } from '@angular/core';
import { Subject } from '../models/subject.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class SubjectService {
    baseUrl = 'https://localhost:7158/api/subject';

    constructor(private http: HttpClient) { }
    getAllSubjects(): Observable<Subject[]> {
        return this.http.get<Subject[]>(this.baseUrl);
    }
    addSubject(subject: Subject): Observable<Subject> {
        subject.id = '0';
        return this.http.post<Subject>(this.baseUrl, subject);
      }
    delSubject(id: string): Observable<Subject>{
        return this.http.delete<Subject>(this.baseUrl+'/'+id);
    }
    updateSubject(subject: Subject): Observable<Subject>{
        return this.http.put<Subject>(this.baseUrl+'/'+subject.id,subject);
    }
}