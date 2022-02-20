import { Component, OnInit } from '@angular/core';
import { AdditionalServiceListModel } from '../../models/listModels/additionalServiceListModel';
import { ListResponseModel } from '../../models/listResponseModel';
import { AdditionalServiceService } from '../../services/additional-service.service';

@Component({
  selector: 'app-additinal-service',
  templateUrl: './additinal-service.component.html',
  styleUrls: ['./additinal-service.component.css'],
})
export class AdditinalServiceComponent implements OnInit {
  additionalServices: ListResponseModel<AdditionalServiceListModel> = {
    items: [],
  };
  selectedList: ListResponseModel<AdditionalServiceListModel> = { items: [] };
  selectedItem: any;

  constructor(private additionalService: AdditionalServiceService) {}

  ngOnInit(): void {
    this.getAdditionalServices();
  }

  getAdditionalServices() {
    this.additionalService.getAdditionalServices(0, 100).subscribe((data) => {
      this.additionalServices = data;
    });
  }

  getSelectedList(selectedItem: AdditionalServiceListModel) {
    console.log('selected item', selectedItem);
  }
}
