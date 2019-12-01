/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Models;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Bence
 */
@XmlRootElement(name = "subscription")
@XmlAccessorType(XmlAccessType.FIELD)
public class Subscription {
    @XmlElement
    int minutePrice;
    @XmlElement
    int monthlyPrice;
    @XmlElement
    String name;

    public Subscription(int minutePrice, int monthlyPrice, String name) {
        this.minutePrice = minutePrice;
        this.monthlyPrice = monthlyPrice;
        this.name = name;
    }

    public int getMinutePrice() {
        return minutePrice;
    }

    public int getMonthlyPrice() {
        return monthlyPrice;
    }

    public String getName() {
        return name;
    }
    
    
}
