import { Component } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.css']
})
export class BaseComponent {
  /**
   *
   */
  constructor(private spinner: NgxSpinnerService) {
  }
  showSpinner(spinnerNameType:SpinnerType) {
    this.spinner.show(spinnerNameType);

    setTimeout(() => {

      this.spinner.hide(spinnerNameType)
    }, 3000);
  }

  hideSpinner(spinnerNameType:SpinnerType)
  {
    this.spinner.hide(spinnerNameType);
  }

}
export enum SpinnerType {
  BallAtom="s1",
  BallScaleMultiple="s2 ",
  BallSpinClockwiseFadeRotating="s3"}
