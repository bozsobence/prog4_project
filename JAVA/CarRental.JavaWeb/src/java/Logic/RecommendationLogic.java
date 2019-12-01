/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Logic;

import Models.Car;
import Models.RecommendedPackage;
import Models.Subscription;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Bence
 */
public class RecommendationLogic {
    
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
        int minPrice = Integer.MAX_VALUE;
        for (Subscription s : subscriptions) {
            if((s.getMinutePrice() * minutes) + s.getMonthlyPrice() < minPrice){
                recommendedSubscription = s;
            }
        }
        for (Car c : cars) {
            if(c.getSize() == size && c.getCategory() == category){
                recommendedCars.add(c);
            }}
        
        return new RecommendedPackage(recommendedSubscription, recommendedCars);
    } 

    public List<Subscription> getSubscriptions() {
        return subscriptions;
    }

    public List<Car> getCars() {
        return cars;
    }
    
    
}
