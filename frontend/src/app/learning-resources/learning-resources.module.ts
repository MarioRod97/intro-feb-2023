import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LearningResourcesComponent } from './learning-resources.component';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ListComponent } from './components/list/list.component';
import { NewComponent } from './components/new/new.component';
import { StoreModule } from '@ngrx/store';
import { featureName, reducers } from './state'


const routes: Routes = [
    {
        path: '',
        component: LearningResourcesComponent,
        children: [
            {
                path: 'overview',
                component: DashboardComponent
            },
            {
                path: 'list',
                component: ListComponent
            },
            {
                path: 'new',
                component: NewComponent
            },
            {
                path: '**',
                redirectTo: 'overview'
            }
        ]
    }
]

@NgModule({
    declarations: [
        LearningResourcesComponent,
        DashboardComponent,
        ListComponent,
        NewComponent
    ],
    imports: [
        CommonModule,
        RouterModule.forChild(routes),
        StoreModule.forFeature(featureName, reducers)
    ]
})
export class LearningResourcesModule { }