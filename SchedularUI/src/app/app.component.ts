import { Component } from '@angular/core';

import { ScheduleService } from './scheduleService';
import { Schedule } from './Model/Schedule';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  schedules$ : Schedule[];
  scheduleService : ScheduleService;
 
  constructor(scheduleService: ScheduleService){
      this.scheduleService = scheduleService;
      
  }

  ngOnInit(){
    
    this.scheduleService.getSchedule().subscribe(
      data => this.schedules$ = data
    );
  
  }
  title = 'SchedularUI';
 
}


