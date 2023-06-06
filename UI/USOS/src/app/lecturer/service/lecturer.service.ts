import { HttpClient } from '@angular/common/http'; 
import { Injectable } from '@angular/core';
import { Lecturer } from '../models/lecturer.model';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class LecturerService {
    baseUrl = 'https://localhost:7158/api/lecturer';
    baseUrlForSubjects = 'https://localhost:7158/api/subject';
    constructor(private http: HttpClient) { }
    getAllLecturers(): Observable<Lecturer[]> {
        return this.http.get<Lecturer[]>(this.baseUrl);
    }
    getAllSubjects(): Observable<string[]> {
        return this.http.get<string[]>(this.baseUrlForSubjects+"/getnames");
    }
    addLecturer(lecturer: Lecturer): Observable<Lecturer> {
        lecturer.lecturerID = '0';
        return this.http.post<Lecturer>(this.baseUrl, lecturer);
      }
    delLecturer(id: string): Observable<Lecturer>{
        return this.http.delete<Lecturer>(this.baseUrl+'/'+id);
    }
    updateLecturer(lecturer: Lecturer): Observable<Lecturer>{
        return this.http.put<Lecturer>(this.baseUrl+'/'+lecturer.lecturerID,lecturer);
    }
    addSubjectsToLecturer(lecturerID: string, subjects: string[]): Observable<string[]>{
        return this.http.post<string[]>(this.baseUrl+'/managesubjects/'+lecturerID,subjects);
    }
    getHisSubjects(lecturerID: string): Observable<string[]>{
        return this.http.get<string[]>(this.baseUrl+'/gethissubjects/'+lecturerID);
    }
}
