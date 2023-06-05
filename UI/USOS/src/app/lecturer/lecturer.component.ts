import { Component, OnInit } from '@angular/core';
import { Lecturer } from './models/lecturer.model';
import { LecturerService } from './service/lecturer.service';
@Component({ templateUrl: 'lecturer.component.html', styleUrls: ['./lecturer.component.css'] })
export class LecturerComponent implements OnInit {
    title = 'USOS';
    lecturers: Lecturer[] = [];
    lecturer: Lecturer = {
        id: '',
        name: '',
        surname: '',
        title: '',
        subjects: ''
    }
    constructor(private lecturerService: LecturerService) {

    }
    ngOnInit(): void {
        this.getAllLecturers();
    }
    getAllLecturers() {
        this.lecturerService.getAllLecturers().subscribe(
            response => {
                this.lecturers = response;
                console.log(response);
            }
        );
    }
    onSubmit() {
        this.lecturerService.addLecturer(this.lecturer).subscribe(
            response => {
              this.getAllLecturers();
              this.lecturer= {
                id: '',
                name: '',
                surname: '',
                title: '',
                subjects: ''
              };
            }
          );
        }
    }
