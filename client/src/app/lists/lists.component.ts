import { Component, OnInit } from '@angular/core';
import { Member } from '../_models/member';
import { MembersService } from '../_services/members.service';
import { Router } from '@angular/router';
import { phoneNumber } from '../_models/phone';
import { Address } from '../_models/address';

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})
export class ListsComponent implements OnInit {
  addMemberRequest: Member ={
    id: 0,
    userName: '',
    email: '',
    dateOfBirth: '',
    addressStreet: '',
    phoneNumberNumber: '',
    PhoneNumbers: [
      {
        id: 0,
        number: '',
        isMain: true,
      }
    ],
    Addresses: [{
      id: 0,
      street: '',
      isMain: true,
    }]

  }

  constructor(private memberService: MembersService, private router: Router){}



  ngOnInit(): void {

  }

  addMember(){
    console.log(this.addMemberRequest); // Просмотр данных перед отправкой
    this.memberService.addMember(this.addMemberRequest)
    .subscribe({
      next: (member) => {
        this.router.navigate(['members']);
      }
      
    });
  }

  addPhoneNumber() {
    this.addMemberRequest.PhoneNumbers.push({
      id: 0,number: '', isMain: false,
    });
  }

  addAddress() {
    this.addMemberRequest.Addresses.push({
      id: 0,street: '', isMain: false,

    });
  }

PhonetoggleIsMain(phone: phoneNumber) {
    phone.isMain = !phone.isMain;
}
AddresstoggleIsMain(street: Address) {
  street.isMain = !street.isMain;
}

}
