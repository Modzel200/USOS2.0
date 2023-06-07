import { HttpClient } from '@angular/common/http'; 
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MajorSubject } from '../models/majorSubject.model';

@Injectable({
    providedIn: 'root'
})
export class MajorSubjectService {
    baseUrl = 'https://localhost:7158/api/majorSubject';
    baseUrlForSubjects = 'https://localhost:7158/api/subject';
    constructor(private http: HttpClient) { }
    getAllMajorSubjects(): Observable<MajorSubject[]> {
        return this.http.get<MajorSubject[]>(this.baseUrl);
    }
    getAllSubjects(): Observable<string[]> {
        return this.http.get<string[]>(this.baseUrlForSubjects+"/getnames");
    }
    addMajorSubject(majorSubject: MajorSubject): Observable<MajorSubject> {
        majorSubject.majorSubjectID = '0';
        return this.http.post<MajorSubject>(this.baseUrl, majorSubject);
      }
    delMajorSubject(id: string): Observable<MajorSubject>{
        return this.http.delete<MajorSubject>(this.baseUrl+'/'+id);
    }
    updateMajorSubject(majorSubject: MajorSubject): Observable<MajorSubject>{
        return this.http.put<MajorSubject>(this.baseUrl+'/'+majorSubject.majorSubjectID,majorSubject);
    }
    addSubjectsToSubject(majorSubjectID: string, subjects: string[]): Observable<string[]>{
        return this.http.post<string[]>(this.baseUrl+'/managesubjects/'+majorSubjectID,subjects);
    }
    getHisSubjects(majorSubjectID: string): Observable<string[]>{
        return this.http.get<string[]>(this.baseUrl+'/getitssubjects/'+majorSubjectID);
    }  
}
