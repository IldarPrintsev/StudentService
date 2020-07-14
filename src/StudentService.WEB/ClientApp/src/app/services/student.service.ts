import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Student } from 'src/app/student-data/student-data.component';

@Injectable()
export class StudentService {

  private url = "/api/student";

  constructor(private http: HttpClient) {
  }

  getStudents() {
    return this.http.get(this.url, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  addStudent(student: Student) {
    return this.http.post(this.url, student, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  updateStudent(student: Student) {
    return this.http.put(this.url, student, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }

  deleteStudent(id: number) {
    return this.http.delete(this.url + '/' + id, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    });
  }
}
