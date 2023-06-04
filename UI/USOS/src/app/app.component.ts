import { Component, OnInit } from '@angular/core';
import { StudentService } from './service/student.service';
import { Student } from './models/student.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'USOS';
  students: Student[] = [];
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
    this.studentService.addStudent(this.student).subscribe(
      response => {
        console.log(response);
      }
    )
  }
}
