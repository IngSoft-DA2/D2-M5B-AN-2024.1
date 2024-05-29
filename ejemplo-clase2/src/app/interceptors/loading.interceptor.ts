import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { finalize } from 'rxjs';
import { ApiService } from '../services/api.service';

export const loadingInterceptor: HttpInterceptorFn = (req, next) => {

  const service = inject(ApiService);

  service.showLoading();

  return next(req).pipe(finalize(() => service.hideLoading()));
};
