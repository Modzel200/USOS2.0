import { Component, OnInit } from '@angular/core';
import { StudentService } from './service/student.service';
import { Student } from './models/student.model';
import { Login } from '../login/models/login.model';
import { LoginComponent } from '../login';

@Component({ templateUrl: 'student.component.html', styleUrls: ['./student.component.css'] })
export class StudentComponent implements OnInit{
    title = 'USOS';
  students: Student[] = [];
  majorSubjects: string[] = [];
  student: Student = {
    id: '',
    name: '',
    surname: '',
    index: '',
    age: '',
    majorSubject: ''
  }
  constructor(private studentService: StudentService) { 
  }
  ngOnInit(): void {
    this.getAllStudents();
    this.getAllMajorsByString();
  }
  getAllStudents() {
    this.studentService.getAllStudents().subscribe(
      response => {
        this.students = response;
        console.log(response);
      }
    );
  }
  onSubmit() {
    if(this.student.id==='')
    {
      this.studentService.addStudent(this.student).subscribe(
        response => {
          this.getAllStudents();
          this.student= {
            id: '',
            name: '',
            surname: '',
            index: '',
            age: '',
            majorSubject: ''
          };
        }
      );
    }else{
      this.updateStudent(this.student);
    }

  }
  deleteStudent(index: string) {
    this.studentService.delStudent(index)
    .subscribe(
      response=>{
        this.getAllStudents();
      }
    );
  }
  populateForm(student: Student){
    this.student = student;
  }
  updateStudent(student: Student)
  {
    this.studentService.updateStudent(student)
    .subscribe(
      response=>{
        this.getAllStudents()
        this.student= {
          id: '',
          name: '',
          surname: '',
          index: '',
          age: '',
          majorSubject: ''
        };
      }
    )
  }
  getAllMajorsByString (){
    this.studentService.getAllMajorsByString().subscribe(
      response => {
        this.majorSubjects = response;
        console.log(response);
      }
    );
  }
}