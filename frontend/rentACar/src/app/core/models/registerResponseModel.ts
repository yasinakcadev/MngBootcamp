import { AccessTokenModel } from './accessTokenModel';


export interface RegisterResponseModel {

  id:number;
  email:string;
  firstName:string;
  lastName:string;
  accessToken: AccessTokenModel;
}
