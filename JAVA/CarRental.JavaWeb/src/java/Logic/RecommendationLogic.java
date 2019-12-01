/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Logic;

import Models.Car;
import Models.RecommendedPackage;
import Models.Subscription;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Bence
 */
public class RecommendationLogic implements Serializable {
    
    List<Subscription> subscriptions;
    List<Car> cars;
    public static RecommendationLogic instance;
    private RecommendationLogic() {
        subscriptions = new ArrayList<Subscription>();
        cars = new ArrayList<Car>();
        subscriptions.add(new Subscription(100, 0, "alkalmi"));
        subscriptions.add(new Subscription(60, 1500, "normál"));
        subscriptions.add(new Subscription(35, 4000, "prémium"));
        cars.add(new Car("Volkswagen", "e-Up", 0, 1, 1));
        cars.add(new Car("Volkswagen", "e-Golf", 20, 2, 2));
        cars.add(new Car("Nissan", "Leaf", 20, 2, 2));
        cars.add(new Car("BMW", "i3", 40, 1, 3));
        cars.add(new Car("Audi", "e-Tron", 60, 3, 3));
    }

    public static RecommendationLogic getInstance() {
        if(instance == null){
            instance = new RecommendationLogic();
        }
        return instance;
    }
    
    public RecommendedPackage getRecommendation(int minutes, int size, int category){
        
        Subscription recommendedSubscription = null;
        List<Car> recommendedCars = new ArrayList<Car>();
        String msg = "";
        int minPrice = Integer.MAX_VALUE;
        for (Subscription s : subscriptions) {
            int actualPrice = (s.getMinutePrice() * minutes) + s.getMonthlyPrice();
            if( actualPrice < minPrice){
                recommendedSubscription = s;
                minPrice = actualPrice;
            }
        }
        for (Car c : cars) {
            if(c.getSize() == size && c.getCategory() == category){
                recommendedCars.add(c);
            }
        }
        if(recommendedCars.isEmpty()){
                msg = "Nem sikerült az igényeinek minden tekintetben megfelelő autót találni, ezért listázzuk az összes lehetőséget.";
                recommendedCars = cars;
        }
        RecommendedPackage r = new RecommendedPackage(recommendedSubscription, recommendedCars, msg);
        r.getSubscription().setFullPrice(minPrice);
        return r;
    } 

    public List<Subscription> getSubscriptions() {
        return subscriptions;
    }

    public List<Car> getCars() {
        return cars;
    }
    
    
}
