import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MajorSubjectService } from './service/majorSubject.service';
import { MajorSubject } from './models/majorSubject.model';
@Component({ templateUrl: 'majorSubject.component.html', styleUrls: ['./majorSubject.component.css'] })
export class majorSubjectComponent implements OnInit {
    title='USOS';
    majorSubjects: MajorSubject[] = [];
    majorSubject: MajorSubject ={
        majorSubjectID: '',
        name: '',
        shortDesc: ''
    }
    majorSubjectInfo: MajorSubject ={
        majorSubjectID: '',
        name: '',
        shortDesc: ''
    }
    addedSubjects: string[] = [];
    allSubjects: string[] = [];
    constructor(private majorSubjectService: MajorSubjectService, private router: Router) { }


    ngOnInit(): void{
        this.getAllMajorSubjects();
    }
    getAllMajorSubjects(){
        this.majorSubjectService.getAllMajorSubjects().subscribe(
            response => {
                this.majorSubjects = response;
                console.log(response);
            }
        );
    }
    getAllSubjects(addedSubjects: string[]) {
        this.majorSubjectService.getAllSubjects().subscribe(
            response => {
                this.allSubjects = response;
                console.log(response);
                for(let sub of this.addedSubjects){
                    if(this.allSubjects.includes(sub)){
                        this.allSubjects.splice(this.allSubjects.indexOf(sub),1);
                    }
                }
            }
        );
    }
    onSubmit() {
        if(this.majorSubject.majorSubjectID==='')
        {
        this.majorSubjectService.addMajorSubject(this.majorSubject).subscribe(
            response => {
              console.log(response);  
              this.getAllMajorSubjects();
              this.majorSubject= {
                majorSubjectID: '',
                name: '',
                shortDesc: ''
              };
            }
          );
        }else{
            this.updateMajorSubject(this.majorSubject);
        }
    }
    deleteMajorSubject(id: string) {
        this.majorSubjectService.delMajorSubject(id)
        .subscribe(
            response=>{
            this.getAllMajorSubjects();
            this.majorSubject= {
                majorSubjectID: '',
                name: '',
                shortDesc: ''
              };
            }

        );
    }
    populateForm(majorSubject: MajorSubject){
        this.majorSubject = majorSubject;
        console.log(this.majorSubject);
        }
        updateMajorSubject(majorSubject: MajorSubject)
        {
        console.log(majorSubject);
        this.majorSubjectService.updateMajorSubject(majorSubject)
        .subscribe(
            response=>{
            this.getAllMajorSubjects()
            this.majorSubject= {
                majorSubjectID: '',
                name: '',
                shortDesc: ''
              };
              }
            )
        }
        moreInfo(majorSubject: MajorSubject){
            this.majorSubjectInfo.majorSubjectID=majorSubject.majorSubjectID,
            this.majorSubjectInfo.name= majorSubject.name,
            this.majorSubjectInfo.shortDesc= majorSubject.shortDesc,
            this.getHisSubjects(majorSubject.majorSubjectID);
            console.log(this.addedSubjects);
        }
        getHisSubjects(majorSubjectID: string){
            this.majorSubjectService.getHisSubjects(majorSubjectID).subscribe(
                response => {
                    this.addedSubjects = response;
                    console.log(response);
                    this.getAllSubjects(this.addedSubjects);
                }
            );
        }
        addToSubjectSubjects(e: any, subject: string){
            if(e.target.checked){
                if(!this.addedSubjects.includes(subject))
                {
                this.addedSubjects.push(subject);
                console.log(this.addedSubjects);
                }
                else{
                    this.addedSubjects.splice(this.addedSubjects.indexOf(subject),1);
                }
        }
        else{
            this.addedSubjects.splice(this.addedSubjects.indexOf(subject),1);
            console.log(this.addedSubjects);
        }
        }
        addSubjectsToSubject(){
            this.majorSubjectService.addSubjectsToSubject(this.majorSubjectInfo.majorSubjectID,this.addedSubjects).subscribe(
                response => {
                  console.log(response);
                }
              );
              this.majorSubjectInfo = {
                majorSubjectID: '',
                name: '',
                shortDesc: ''
            }
            this.addedSubjects = [];
        }
        deleteSubject(subject: string){
            this.addedSubjects.splice(this.addedSubjects.indexOf(subject),1);
        }
}