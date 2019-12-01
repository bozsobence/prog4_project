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
@XmlRootElement(name = "subscription")
@XmlAccessorType(XmlAccessType.FIELD)
public class Subscription implements Serializable{
    @XmlElement
    int minutePrice;
    @XmlElement
    int monthlyPrice;
    @XmlElement
    String name;
    @XmlElement
    int fullPrice;

    public Subscription() {
    }

    
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

    public int getFullPrice() {
        return fullPrice;
    }

    public void setFullPrice(int fullPrice) {
        this.fullPrice = fullPrice;
    }
    
    public String getName() {
        return name;
    }
    
    
}
