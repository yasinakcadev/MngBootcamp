import { AdditionalServiceListModel } from './../../../core/models/listModels/additionalServiceListModel';
export interface RentModel{

  id:number;
  takingCityId:number;
  givingCityId:number;
  userId:number;
  totalRentDay:number;
  additionalServices:AdditionalServiceListModel[]
}
