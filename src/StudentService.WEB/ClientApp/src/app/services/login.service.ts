import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from "@angular/router";

@Injectable()
export class LoginService {

  private url = "/api/auth/login";

  constructor(private router: Router, private http: HttpClient) {}

  login(form: NgForm): boolean {
    const credentials = JSON.stringify(form.value);
    var invalidLogin = true;

    this.http.post(this.url, credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      const token = (<any>response).token;
      localStorage.setItem("jwt", token);
      invalidLogin = false;
      this.router.navigate(["/"]);
    }, err => {
      invalidLogin = true
    });

    return invalidLogin;
  }
}
