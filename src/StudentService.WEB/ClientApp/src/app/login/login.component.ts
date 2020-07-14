import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  providers: [LoginService]
})
export class LoginComponent {
  invalidLogin: boolean;

  constructor(private loginService: LoginService) { }

  login(form: NgForm) {
    this.invalidLogin = this.loginService.login(form);
  }
}
