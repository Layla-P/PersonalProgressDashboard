import {Component, Input, OnDestroy} from "@angular/core";

@Component({
  //moduleId: module.id,
  selector: 'sk-three-bounce',
  styles: [`

    .taking-longer {
      text-align:center;
    }

    .three-bounce-spinner {
      margin: 25px auto;
      width: 70px;
    }
    
    .three-bounce-spinner > div {
      display: inline-block;
      width: 18px;
      height: 18px;
    
      border-radius: 100%;
      background-color: #333;
      -webkit-animation: sk-bouncedelay 1.4s infinite ease-in-out both;
      animation: sk-bouncedelay 1.4s infinite ease-in-out both;
    }
    
    .three-bounce-spinner .bounce1 {
      -webkit-animation-delay: -0.32s;
      animation-delay: -0.32s;
    }
    
    .three-bounce-spinner .bounce2 {
      -webkit-animation-delay: -0.16s;
      animation-delay: -0.16s;
    }
    
    @-webkit-keyframes sk-bouncedelay {
      0%, 80%, 100% {
        -webkit-transform: scale(0)
      }
      40% {
        -webkit-transform: scale(1.0)
      }
    }
    
    @keyframes sk-bouncedelay {
      0%, 80%, 100% {
        -webkit-transform: scale(0);
        transform: scale(0);
      }
      40% {
        -webkit-transform: scale(1.0);
        transform: scale(1.0);
      }
    }
  `],
  template: `
    <div *ngIf="isVisible" class="three-bounce-spinner">
      <div class="bounce1"></div>
      <div class="bounce2"></div>
      <div class="bounce3"></div>
    </div>

        <div *ngIf="isVisible && isTakingLonger" class='col-md-4 col-md-offset-4 panel panel-info' style='padding: 0;'>
            <div class="panel-heading"><i class="fa fa-info-circle fa-lg"></i> Please wait a few moments more ... </div>
            <div class="panel-body">
                <p>It looks like the server hasn't been used for a while and it's nodded off to sleep - 
                we're giving it a kick now, so it should be wide-awake for you in a moment!</p>
            </div>
        </div>

  `
})

export class ThreeBounceComponent implements OnDestroy {
  
  private isVisible:boolean = true;
  private timeout:any;
  private isTakingLonger: boolean = false;

  @Input()
  public delay:number = 0;

  @Input()
  public set isRunning(value:boolean) {
    
    if (!value) {
      this.cancel();
      this.isVisible = false;
      this.isTakingLonger = false;
    }

    if (this.timeout) {
      return;
    }

    this.timeout = setTimeout(() => {
      this.isVisible = value;
      this.cancel();

          setTimeout(() => {
            this.isTakingLonger = true;
          }, 5000);

    }, this.delay);
  }

  private cancel():void {
    clearTimeout(this.timeout);
    this.timeout = undefined;
  }

  ngOnDestroy():any {
    this.cancel();
  }
}
