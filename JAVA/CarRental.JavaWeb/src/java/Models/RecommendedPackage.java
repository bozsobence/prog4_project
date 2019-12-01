/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Models;

import java.io.Serializable;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Bence
 */
@XmlRootElement(name = "recommendedPackage")
@XmlAccessorType(XmlAccessType.FIELD)
public class RecommendedPackage implements Serializable{
    @XmlElement(name = "subscription")
    Subscription subscription;
    @XmlElement(name = "car")
    List<Car> recommendedCars;
    @XmlElement(name = "msg")
    String message;

    public RecommendedPackage() {
    }
    
    public RecommendedPackage(Subscription subscription, List<Car> recommendedCars, String msg) {
        this.subscription = subscription;
        this.recommendedCars = recommendedCars;
        this.message = msg;
    }

    public Subscription getSubscription() {
        return subscription;
    }

    public void setSubscription(Subscription subscription) {
        this.subscription = subscription;
    }

    public List<Car> getRecommendedCars() {
        return recommendedCars;
    }
    
    
    
    
    
}
