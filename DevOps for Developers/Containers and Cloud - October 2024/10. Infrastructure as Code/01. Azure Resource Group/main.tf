terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "4.12.0"
    }
  }
}

provider "azurerm" {
  subscription_id = "8c6b5631-6453-4b9c-886e-7cbd156191f0"
  features {}
}

resource "azurerm_resource_group" "arg" {
  name     = "chrisi"
  location = "West Europe"
}