import { AdditionalServiceListModel } from './../../../core/models/listModels/additionalServiceListModel';
export interface RentModel{

  id:number;
  takingCityId:number;
  givingCityId:number;
  customerId:number;
  totalRentDay:number;
  additionalServices:number[]
}
