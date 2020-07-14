import { HttpClientTestingModule } from '@angular/common/http/testing';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import { StudentService } from 'src/app/services/student.service';
import { StudentDataComponent } from 'src/app/student-data/student-data.component';


describe('StudentDataComponent', () => {
  let component: StudentDataComponent;
  let fixture: ComponentFixture<StudentDataComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [StudentDataComponent],
      imports: [FormsModule, NgxPaginationModule, HttpClientTestingModule ],
      providers: [StudentService]

    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentDataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
})
