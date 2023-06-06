import { Component, OnInit } from '@angular/core';
import { Lecturer } from './models/lecturer.model';
import { LecturerService } from './service/lecturer.service';
@Component({ templateUrl: 'lecturer.component.html', styleUrls: ['./lecturer.component.css'] })
export class LecturerComponent implements OnInit {
    title = 'USOS';
    lecturers: Lecturer[] = [];
    lecturer: Lecturer = {
        lecturerID: '',
        name: '',
        surname: '',
        academicTitle: ''
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
        if(this.lecturer.lecturerID==='')
        {
        this.lecturerService.addLecturer(this.lecturer).subscribe(
            response => {
              console.log(response);  
              this.getAllLecturers();
              this.lecturer= {
                lecturerID: '',
                name: '',
                surname: '',
                academicTitle: ''
              };
            }
          );
        }else{
            this.updateLecturer(this.lecturer);
        }
    }
    deleteLecturer(id: string) {
        this.lecturerService.delLecturer(id)
        .subscribe(
            response=>{
            this.getAllLecturers();
            }
        );
    }
    populateForm(lecturer: Lecturer){
        this.lecturer = lecturer;
        console.log(this.lecturer);
        }
        updateLecturer(lecturer: Lecturer)
        {
        console.log(lecturer);
        this.lecturerService.updateLecturer(lecturer)
        .subscribe(
            response=>{
            this.getAllLecturers()
            this.lecturer= {
                lecturerID: '',
                name: '',
                surname: '',
                academicTitle: ''
              };
              }
            )
        }       
    }