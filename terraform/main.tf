terraform {

    backend "azurerm"{
        resource_group_name = "sbsrg"
        storage_account_name = "sbsterraform"
        container_name = "terraform"
    }
}

    provider "azurerm" {
        version= "=1.38.0"
    }

    resource "azurerm_resource_group" "sbsrg"{
        name = "sbsrg"
        location = "Central US"
    }

    resource "azurerm_app_service_plan" "appSvcPlan" {
        name = "sbsplan"
        location = azurerm_resource_group.sbsrg.location
        resource_group_name = azurerm_resource_group.sbsrg.name

        sku{
            tier = "Free"
            size = "F1"
        }
    }

    resource "azurerm_app_service" "sbsapp"{
        name = "sbsapp"
        location = azurerm_resource_group.sbsrg.location
        resource_group_name = azurerm_resource_group.sbsrg.name
        app_service_plan_id = azurerm_app_service_plan.appSvcPlan.id

        site_config {
            dotnet_framework_version = "v4.0"
            scm_type = "LocalGit"
            use_32_bit_worker_process = true
        }

        app_settings = {
        
        }
    }
