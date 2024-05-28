import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './components/admin/admin.component';
import { CharacterFormComponent } from './components/character-form/character-form.component';
import { CharacterListComponent } from './components/character-list/character-list.component';
import { AuthGuard } from './guards/auth.guard';
import { RoleGuard } from './guards/role.guard';
import { ADMIN_URL, CHARACTER_FORM_URL, CHARACTER_LIST_URL, LOGIN_URL } from './utils/routes';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  { path: '', component: CharacterListComponent },
  { path: CHARACTER_LIST_URL, component: CharacterListComponent },
  {
    path: CHARACTER_FORM_URL,
    component: CharacterFormComponent,
    canActivate: [AuthGuard],
  },
  {
    path: ADMIN_URL,
    component: AdminComponent,
    canActivate: [RoleGuard],
    data: {
      expectedRole: 'admin'
    },
  },
  { path: LOGIN_URL, component: LoginComponent },
  { path: '**', redirectTo: '' }, // this line goes at the end
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
