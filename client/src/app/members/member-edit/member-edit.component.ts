import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { Member } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MembersService } from 'src/app/_services/members.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  member: Member | undefined;

  user: User | null = null;

  memberDetails: Member = {
    id: 0,
    userName: '',
    email: '',
    dateOfBirth: '',
    addressStreet: '',
    phoneNumberNumber: '',
    PhoneNumbers: [],
    Addresses: []
  }

  constructor(private accountService: AccountService, private memberService: MembersService, private route: ActivatedRoute,private router: Router) { 
      this.accountService.currentUser$.pipe(take(1)).subscribe({
         next : user => this.user = user
      })
  }


  ngOnInit(): void {
    this.loadMember();

  }

  updateMember(){
    this.memberService.updateMember(this.memberDetails.id, this.memberDetails ).subscribe({
      next: (response) => {
        this.router.navigate(['members']);
      }
    });
  }

  deleteMember(id: number){
    this.memberService.deleteMember(id).subscribe({
      next: (response) =>{
        this.router.navigate(['members']);

      }
    })
  }

  loadMember(){
    const username = this.route.snapshot.paramMap.get('username');
  
    if (!username) return; {
      this.memberService.getMember(username).subscribe({
        next: (response) => {
          this.memberDetails = response;
        }
      });
    }

  }

  getMainPhoneNumber(){
    if (!this.memberDetails) {
      return null;
    }

    return this.memberDetails.PhoneNumbers?.find(p => p.isMain)?.number;
  }

  getMainAddress() {
    if (!this.memberDetails) {
      return null;
    }

    return this.memberDetails.Addresses?.find(a => a.isMain)?.street;
  }

  

  



  }






