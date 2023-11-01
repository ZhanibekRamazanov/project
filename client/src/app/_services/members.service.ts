import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Member } from '../_models/member';
import { User } from '../_models/user';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getMembers(){
    return this.http.get<Member[]>(this.baseUrl + 'users');
  }

  getMember(id: string){
    return this.http.get<Member>(this.baseUrl + 'users/' + id);
    
  }

  





  addMember(addMemberRequest: Member): Observable<Member>{
    return this.http.post<Member>(this.baseUrl + 'users/', addMemberRequest);

  }

  updateMember(id: number, updateMemberRequest: Member): Observable<Member>{
    return this.http.put<Member>(this.baseUrl + 'users/' + id, updateMemberRequest )
  }


  deleteMember(id: number): Observable<Member>{
    return this.http.delete<Member>(this.baseUrl + 'users/' + id )

  }
  
  


}
