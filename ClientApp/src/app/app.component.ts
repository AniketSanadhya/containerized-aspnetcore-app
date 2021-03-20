import { HomeService } from './home/home.service';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'ClientApp';

  constructor(public homeService: HomeService){
    this.getCars();
  }

  getCars(){
    this.homeService.getCars().subscribe(response=>{
      console.log('response: ',response);
      
    })
  }

}
