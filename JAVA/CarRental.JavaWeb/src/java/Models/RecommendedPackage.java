/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Models;

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
public class RecommendedPackage {
    @XmlElement
    Subscription subscription;
    @XmlElement
    List<Car> recommendedCars;

    public RecommendedPackage(Subscription subscription, List<Car> recommendedCars) {
        this.subscription = subscription;
        this.recommendedCars = recommendedCars;
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
