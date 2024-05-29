import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const authenticationGuard: CanActivateFn = (route, state) => {
  const router = inject(Router);
  const token = localStorage.getItem('auth-token');
  if (token === 'soy-yo') return true;
  else {
    alert("NECEISTA AUTENTICARSE");
    router.navigate(['']);
    return false;
  }
};