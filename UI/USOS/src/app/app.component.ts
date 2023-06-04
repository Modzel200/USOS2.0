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
  constructor(private studentService: StudentService) { 

  }
  ngOnInit(): void {
    this.getAllStudents();
  }
  getAllStudents() {
    this.studentService.getAllStudents().subscribe(
      response => {
        this.students = response;
      }
    );
  }
}
