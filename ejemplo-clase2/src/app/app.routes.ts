import { Routes } from '@angular/router';
import { ItemListComponent } from './views/item-list/item-list.component';
import { ItemDetailComponent } from './views/item-detail/item-detail.component';
import { authenticationGuard } from './guards/authentication.guard';

export const routes: Routes = [
    { path: '', component: ItemListComponent },
    { path: 'item/:id', component: ItemDetailComponent, canActivate: [authenticationGuard] }
];
