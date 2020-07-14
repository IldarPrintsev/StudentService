import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { inject, TestBed } from '@angular/core/testing';
import { StudentService } from 'src/app/services/student.service';
import { Student } from 'src/app/student-data/student-data.component';


const mockData = [
  { id: 1, name: 'Tom', dateOfBirth: new Date(1980, 5, 10), email: 'tom@gmail.com' },
  { id: 2, name: 'Bob', dateOfBirth: new Date(1990, 4, 11), email: 'bob@gmail.com' },
  { id: 3, name: 'Sam', dateOfBirth: new Date(1996, 6, 12), email: 'sam@gmail.com' }
] as Student[];

describe('StudentService', () => {

  let service;
  let httpTestingController: HttpTestingController;
  let mockStudents: Student[];
  let mockStudent: Student = new Student();

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule
      ],
      providers: [StudentService]
    });
    httpTestingController = TestBed.get(HttpTestingController);
  });

  beforeEach(inject([StudentService], s => {
    service = s;
  }));

  beforeEach(() => {
    mockStudents = [...mockData];
    mockStudent = mockStudents[0];
  });

  afterEach(() => {
    httpTestingController.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  describe('getStudents', () => {

    it('should return mock students', () => {
      service.getStudents().subscribe(
        students => expect(students.length).toEqual(mockStudents.length),
        fail
      );

      const req = httpTestingController.expectOne(service.url);
      expect(req.request.method).toEqual('GET');

      req.flush(mockStudents);
    });
  });

  describe('updateStudent', () => {

    it('should update student', () => {
      service.updateStudent(mockStudent).subscribe(
        response => expect(response).toEqual(mockStudent),
        fail
      );

      const req = httpTestingController.expectOne(service.url);
      expect(req.request.method).toEqual('PUT');

      req.flush(mockStudent);
    });
  });

  describe('deleteStudent', () => {

    it('should delete student using id', () => {
      const mockUrl = service.url + "/" + mockStudent.id;
      service.deleteStudent(mockStudent.id).subscribe(
        response => expect(response).toEqual(mockStudent.id),
        fail
      );

      const req = httpTestingController.expectOne(mockUrl);
      expect(req.request.method).toEqual('DELETE');

      req.flush(mockStudent.id);
    });
  });
});
