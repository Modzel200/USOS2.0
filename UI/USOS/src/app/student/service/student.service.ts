import { HttpClient } from '@angular/common/http'; 
import { Injectable } from '@angular/core';
import { Student } from '../models/student.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  baseUrl = 'https://localhost:7158/api/student';
  baseUrlMajor = 'https://localhost:7158/api/majorSubject';
  constructor(private http: HttpClient) { }

  // Get all students
  getAllStudents(): Observable<Student[]> {
    return this.http.get<Student[]>(this.baseUrl);
  }
  addStudent(student: Student): Observable<Student> {
    student.id = '0';
    return this.http.post<Student>(this.baseUrl, student);
  }
  delStudent(index: string): Observable<Student>{
    return this.http.delete<Student>(this.baseUrl+'/'+index);
  }
  updateStudent(student: Student): Observable<Student>{
    return this.http.put<Student>(this.baseUrl+'/'+student.index,student);
  }
  getAllMajorsByString(): Observable<string[]>{
    return this.http.get<string[]>(this.baseUrlMajor+'/getallmajorsubjects');
  }
}
