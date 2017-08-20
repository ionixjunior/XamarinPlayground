//
//  ViewController.m
//  iOS
//
//  Created by Ione Souza Junior on 20/08/17.
//  Copyright © 2017 Ione Souza Junior. All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@property (weak, nonatomic) IBOutlet UILabel *lbDescricao;
- (IBAction)btCarregar:(UIButton *)sender;

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view, typically from a nib.
}


- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}


- (IBAction)btCarregar:(UIButton *)sender {
    _lbDescricao.text = @"XOWeek - iOS";
}
@end
