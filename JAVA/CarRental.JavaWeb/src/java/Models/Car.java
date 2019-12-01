/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Models;

import java.io.Serializable;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Bence
 */
@XmlRootElement(name = "car")
@XmlAccessorType(XmlAccessType.FIELD)
public class Car implements Serializable {
    @XmlElement(name = "brand")
    String brand;
    @XmlElement
    String model;
    @XmlElement
    int extraPrice;
    @XmlElement
    int size;
    @XmlElement
    int category;

    public Car() {
    }
    
    public Car(String brand, String model, int extraPrice, int size, int category) {
        this.brand = brand;
        this.model = model;
        this.extraPrice = extraPrice;
        this.size = size;
        this.category = category;
    }

    public String getBrand() {
        return brand;
    }

    public String getModel() {
        return model;
    }

    public int getExtraPrice() {
        return extraPrice;
    }

    public int getSize() {
        return size;
    }

    public int getCategory() {
        return category;
    }
    

    

   
    
}
