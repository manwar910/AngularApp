import { Component, EventEmitter, Output } from '@angular/core';
import { AlertService, MessageSeverity } from '../../services/alert.service';
import { CustomerService } from '../../services/customer.service';
import { Customer } from '../../models/customer';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent {
 
  list :any [];
  customer :Customer
  IsEdit:boolean=false;
  btnSavetxt:string="Save";
  formtext:string="Add";
  constructor(private alertService: AlertService, private customerService: CustomerService) {
  }

  ngOnInit() {
    this.customer=new Customer();
      this.loadCurrentUserData();
      this.alertService.stopLoadingMessage();
  }
  private loadCurrentUserData()  {
    this.alertService.startLoadingMessage();
   this.customerService.getCustomersList()
   .subscribe({
     next: user => this.onCurrentUserDataLoadSuccessful(user),
     error: error => this.onCurrentUserDataLoadFailed(error)
   });   
  }
  private onCurrentUserDataLoadSuccessful(list) {
    this.list= list;
  }
  private onCurrentUserDataLoadFailed(list) {
    var list= list;
  }
  public AddCustomer() {
    this.IsEdit=true;
    this.customer=new Customer();
    this.customer.customerId=0;
    this.btnSavetxt="Save";
    this.formtext="Add";

  }
  public EditCustomer(data) {
    this.customer=data;
    this.IsEdit=true;
    this.btnSavetxt="Update";
    this.formtext="Edit";

  }
  public resetForm() {
    this.IsEdit=false;
    this.customer=new Customer();
    this.loadCurrentUserData();
    this.alertService.stopLoadingMessage();
  }
  
  save() {
    this.alertService.startLoadingMessage('Saving changes...');

      this.customerService.Save(this.customer)
        .subscribe({
          next: customer => this.saveSuccessHelper(this.customer),
          error: error => this.saveFailedHelper(error)
        });
    
  }

  private saveSuccessHelper(newcustomer?: Customer) {
   if (newcustomer) {
      Object.assign(this.customer, newcustomer);
    }


    this.alertService.stopLoadingMessage();

    this.customer = new Customer();
   


    if (this.IsEdit) {
      this.alertService.showMessage('Success', 'Changes to your User Profile was saved successfully', MessageSeverity.success);
    }
    else{
      this.alertService.showMessage('Success', 'Customer saved successfully', MessageSeverity.success);
    }

    this.resetForm();

  }

  private saveFailedHelper(error: HttpErrorResponse) {
   this.alertService.stopLoadingMessage();
    this.alertService.showStickyMessage('Save Error', 'The below errors occurred whilst saving your changes:', MessageSeverity.error, error);
    this.alertService.showStickyMessage(error, null, MessageSeverity.error);
  }

  public Cancel() {
    this.IsEdit=false;
  }
}
