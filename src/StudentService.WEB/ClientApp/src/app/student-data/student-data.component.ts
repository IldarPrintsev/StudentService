import { Component, Input, OnInit } from '@angular/core';
import { StudentService } from 'src/app/services/student.service';
import { PaginationInstance } from 'ngx-pagination';

@Component({
  selector: 'app-student-data',
  templateUrl: './student-data.component.html',
  styleUrls: ['./student-data.component.css'],
  providers: [StudentService]
})
export class StudentDataComponent implements OnInit {
  student: Student = new Student();
  newStudent: Student = new Student();
  @Input('data') students: Student[] = [];

  constructor(private studentService: StudentService) { }

  ngOnInit() {
    this.getStudents();
  }

  getStudents() {
    this.studentService.getStudents()
      .subscribe((data: Student[]) =>
        this.students = data
        , err => {
          console.log(err);
        });
  }

  saveStudent() {
    if (this.student.id != null) {
      this.studentService.updateStudent(this.student)
        .subscribe(() => this.getStudents());
      this.cancel();
    } else {
      this.studentService.addStudent(this.newStudent)
        .subscribe((data: Student) => this.students.push(data));
      this.newStudent = new Student();
    }
  }

  editStudent(s: Student) {
    this.student = new Student(s.id, s.name, s.dateOfBirth, s.email);
  }

  cancel() {
    this.student = new Student();
  }

  deleteStudent(s: Student) {
    this.studentService.deleteStudent(s.id)
      .subscribe(() => this.getStudents());
  }

  public maxSize: number = 7;
  public directionLinks: boolean = true;
  public autoHide: boolean = false;
  public responsive: boolean = false;
  public config: PaginationInstance = {
    id: 'advanced',
    itemsPerPage: 10,
    currentPage: 1
  };
  public labels: any = {
    previousLabel: 'Previous',
    nextLabel: 'Next',
    screenReaderPaginationLabel: 'Pagination',
    screenReaderPageLabel: 'page',
    screenReaderCurrentLabel: `You're on page`
  };

  onPageChange(number: number) {
    this.config.currentPage = number;
  }

  onPageBoundsCorrection(number: number) {
    this.config.currentPage = number;
  }
}

export class Student {
  constructor(
    public id?: number,
    public name?: string,
    public dateOfBirth?: Date,
    public email?: string) { }
}
