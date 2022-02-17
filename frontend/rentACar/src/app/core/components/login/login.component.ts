import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoginModel } from '../../models/loginModel';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  login() {
    if (!this.loginForm.valid) {
      this.toastrService.warning('There are missing fields.');
      return;
    }
    let userToLogin: LoginModel = { ...this.loginForm.value };
    this.authService.login(userToLogin).subscribe((response) => {
      console.log('response', response);
      localStorage.setItem('token', response.accessToken.token);
      this.toastrService.success('User logged in.');
    });

    this.router.navigateByUrl('');
  }
}
