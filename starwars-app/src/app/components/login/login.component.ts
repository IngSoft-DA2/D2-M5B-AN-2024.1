import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { UsersService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  numberList = []
  constructor(
    private _userService: UsersService,
    private _authService: AuthService,
    private _route: ActivatedRoute,
    private _router: Router) {}

  ngOnInit(): void {}

  login() {
    this._userService.login()
    .subscribe((data) => {
      this._authService.setToken(data.token)
      let urlToGo;
      this._route?.queryParams.forEach((value: any) => {
        if (value?.returnUrl) {
          urlToGo = value?.returnUrl;
        }
      });
      if (urlToGo) {
        this._router.navigate([urlToGo]);
      }
    });
  }

  isLoggedIn(): boolean {
    return localStorage.getItem('userInfo') != null;
  }

  logout() {
    // localStorage.clear()
    localStorage.removeItem('userInfo');
  }

  private saveUserInfo(userInfo: string): void {
    localStorage.setItem('userInfo', userInfo);
  }
}
