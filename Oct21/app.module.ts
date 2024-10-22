import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
// Remove declarations for standalone components
// Import the standalone components instead
import { importProvidersFrom } from '@angular/core';  // Import providers for standalone components
import { JobListComponent } from './components/job-list/job-list.component'; // This should be standalone
import { JobDetailComponent } from './components/job-detail/job-detail.component'; // This should be standalone
import { UserProfileComponent } from './components/user-profile/user-profile.component'; // This should be standalone
import { SkillAssessmentComponent } from './components/skill-assessment/skill-assessment.component'; // This should be standalone

@NgModule({
  declarations: [
    AppComponent // Only non-standalone components
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', redirectTo: '/jobs', pathMatch: 'full' },
      { path: 'jobs', component: JobListComponent }, // Use standalone component directly
      { path: 'jobs/:id', component: JobDetailComponent }, // Use standalone component directly
      { path: 'profile', component: UserProfileComponent }, // Use standalone component directly
      { path: 'assessment', component: SkillAssessmentComponent } // Use standalone component directly
    ]),
  ],
  bootstrap: [AppComponent],
  providers: [] // No need to declare standalone components here
})
export class AppModule { }
